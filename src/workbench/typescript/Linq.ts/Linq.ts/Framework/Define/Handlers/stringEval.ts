﻿/// <reference path="../../../DOM/DOMEnumerator.ts" />

namespace Internal.Handlers {

    const events = {
        onclick: "onclick"
    }
    const eventFuncNames: string[] = Object.keys(events);

    export function hasKey(object: object, key: string): boolean {
        // hasOwnProperty = Object.prototype.hasOwnProperty
        return object ? window.hasOwnProperty.call(object, key) : false;
    }

    /**
     * 这个函数确保给定的id字符串总是以符号``#``开始的
    */
    export function EnsureNodeId(str: string): string {
        if (!str) {
            throw "The given node id value is nothing!";
        } else if (str[0] == "#") {
            return str;
        } else {
            return "#" + str;
        }
    }

    /**
     * 字符串格式的值意味着对html文档节点的查询
    */
    export class stringEval implements IEval<string> {

        private static ensureArguments(args: object): Arguments {
            if (isNullOrUndefined(args)) {
                return Arguments.Default();
            } else {
                var opts = <Arguments>args;

                // 2018-10-16
                // 如果不在这里进行判断赋值，则nativeModel属性的值为undefined
                // 会导致总会判断为true的bug出现
                if (isNullOrUndefined(opts.nativeModel)) {
                    // 为了兼容以前的代码，在这里总是默认为TRUE
                    opts.nativeModel = true;
                }

                return opts;
            }
        }

        /**
         * @param query 函数会在这里自动的处理转义问题
         * @param context 默认为当前的窗口文档
        */
        public static select<T extends HTMLElement>(query: string, context: Window | HTMLElement = window): DOMEnumerator<T> {
            // https://mathiasbynens.be/notes/css-escapes
            var cssSelector: string = query.replace(":", "\\:");
            // 返回节点集合
            var nodes: NodeListOf<HTMLElement>;

            if (context instanceof Window) {
                nodes = context
                    .document
                    .querySelectorAll(cssSelector);
            } else if (context instanceof HTMLElement) {
                nodes = context.querySelectorAll(cssSelector);
            } else {
                throw `Unsupported context type: ${TypeInfo.getClass(context)}`;
            }

            var it = new DOMEnumerator<T>(<any>nodes);

            return it;
        }

        doEval(expr: string, type: TypeInfo, args: object): any {
            var query: DOM.Query = DOM.Query.parseQuery(expr);
            var argument: Arguments = stringEval.ensureArguments(args);
            // 默认查询的上下文环境为当前的文档
            var context: Window = argument.context || window;

            if (query.type == DOM.QueryTypes.id) {
                // 按照id查询
                var node: HTMLElement = context
                    .document
                    .getElementById(query.expression);

                if (isNullOrUndefined(node)) {
                    if (Internal.outputWarning()) {
                        console.warn(`Unable to found a node which its ID='${expr}'!`);
                    }

                    return null;
                } else {
                    if (argument.nativeModel) {
                        return TypeExtensions.Extends(node);
                    } else {
                        return new HTMLTsElement(node);
                    }
                }
            } else if (query.type == DOM.QueryTypes.NoQuery) {
                return stringEval.createNew(expr, argument, context);
            } else if (!query.singleNode) {
                return stringEval.select(query.expression, context);
            } else if (query.type == DOM.QueryTypes.QueryMeta) {
                // meta标签查询默认是可以在父节点文档之中查询的
                // 所以在这里不需要context上下文环境
                return DOM.metaValue(query.expression, (args || {})["default"], context != window);
            } else {

                if (Internal.outputEverything()) {
                    console.warn(`Apply querySelector for expression: '${query.expression}', no typescript extension was made!`);
                }

                // 只返回第一个满足条件的节点
                return context
                    .document
                    .querySelector(query.expression);
            }
        }

        /**
         * 创建新的HTML节点元素
        */
        public static createNew(expr: string, args: Arguments, context: Window = window): HTMLElement | HTMLTsElement {
            var declare = DOM.ParseNodeDeclare(expr);
            var node: HTMLElement = context
                .document
                .createElement(declare.tag);

            // 赋值节点申明的字符串表达式之中所定义的属性
            declare.attrs
                .forEach(attr => {
                    if (eventFuncNames.indexOf(attr.name) < 0) {
                        node.setAttribute(attr.name, attr.value);
                    }
                });

            // 赋值额外的属性参数
            if (args) {
                stringEval.setAttributes(node, args);
            }

            if (args.nativeModel) {
                return TypeExtensions.Extends(node);
            } else {
                return new HTMLTsElement(node);
            }
        }

        public static setAttributes(node: HTMLElement, attrs: object) {
            var setAttr = function (name: string) {
                if (eventFuncNames.indexOf(name) > -1) {
                    return;
                }

                if (name == "class") {
                    var classVals = attrs[name];

                    if (Array.isArray(classVals)) {
                        (<string[]>classVals).forEach(c => node.classList.add(c));
                    } else {
                        node.setAttribute(name, <string>classVals);
                    }

                } else {
                    node.setAttribute(name, <string>attrs[name]);
                }
            }

            Arguments.nameFilter(attrs).forEach(name => setAttr(name));

            // 添加事件
            if (hasKey(attrs, events.onclick)) {
                let onclick: string | Delegate.Sub = attrs[events.onclick];

                if (typeof onclick == "string") {
                    node.setAttribute(events.onclick, onclick);
                } else {
                    node.onclick = onclick;
                }
            }
        }
    }
}