﻿namespace Internal {

    interface HTMLElementTagNameMap {
        "<a>": HTMLAnchorElement;
        "abbr": HTMLElement;
        "acronym": HTMLElement;
        "address": HTMLElement;
        "applet": HTMLAppletElement;
        "area": HTMLAreaElement;
        "article": HTMLElement;
        "aside": HTMLElement;
        "audio": HTMLAudioElement;
        "b": HTMLElement;
        "base": HTMLBaseElement;
        "basefont": HTMLBaseFontElement;
        "bdo": HTMLElement;
        "big": HTMLElement;
        "blockquote": HTMLQuoteElement;
        "body": HTMLBodyElement;
        "br": HTMLBRElement;
        "button": HTMLButtonElement;
        "canvas": HTMLCanvasElement;
        "caption": HTMLTableCaptionElement;
        "center": HTMLElement;
        "cite": HTMLElement;
        "code": HTMLElement;
        "col": HTMLTableColElement;
        "colgroup": HTMLTableColElement;
        "data": HTMLDataElement;
        "datalist": HTMLDataListElement;
        "dd": HTMLElement;
        "del": HTMLModElement;
        "dfn": HTMLElement;
        "dir": HTMLDirectoryElement;
        "div": HTMLDivElement;
        "dl": HTMLDListElement;
        "dt": HTMLElement;
        "em": HTMLElement;
        "embed": HTMLEmbedElement;
        "fieldset": HTMLFieldSetElement;
        "figcaption": HTMLElement;
        "figure": HTMLElement;
        "font": HTMLFontElement;
        "footer": HTMLElement;
        "form": HTMLFormElement;
        "frame": HTMLFrameElement;
        "frameset": HTMLFrameSetElement;
        "h1": HTMLHeadingElement;
        "h2": HTMLHeadingElement;
        "h3": HTMLHeadingElement;
        "h4": HTMLHeadingElement;
        "h5": HTMLHeadingElement;
        "h6": HTMLHeadingElement;
        "head": HTMLHeadElement;
        "header": HTMLElement;
        "hgroup": HTMLElement;
        "hr": HTMLHRElement;
        "html": HTMLHtmlElement;
        "i": HTMLElement;
        "iframe": HTMLIFrameElement;
        "img": HTMLImageElement;
        "input": HTMLInputElement;
        "ins": HTMLModElement;
        "isindex": HTMLUnknownElement;
        "kbd": HTMLElement;
        "keygen": HTMLElement;
        "label": HTMLLabelElement;
        "legend": HTMLLegendElement;
        "li": HTMLLIElement;
        "link": HTMLLinkElement;
        "listing": HTMLPreElement;
        "map": HTMLMapElement;
        "mark": HTMLElement;
        "marquee": HTMLMarqueeElement;
        "menu": HTMLMenuElement;
        "meta": HTMLMetaElement;
        "meter": HTMLMeterElement;
        "nav": HTMLElement;
        "nextid": HTMLUnknownElement;
        "nobr": HTMLElement;
        "noframes": HTMLElement;
        "noscript": HTMLElement;
        "object": HTMLObjectElement;
        "ol": HTMLOListElement;
        "optgroup": HTMLOptGroupElement;
        "option": HTMLOptionElement;
        "output": HTMLOutputElement;
        "p": HTMLParagraphElement;
        "param": HTMLParamElement;
        "picture": HTMLPictureElement;
        "plaintext": HTMLElement;
        "pre": HTMLPreElement;
        "progress": HTMLProgressElement;
        "q": HTMLQuoteElement;
        "rt": HTMLElement;
        "ruby": HTMLElement;
        "s": HTMLElement;
        "samp": HTMLElement;
        "script": HTMLScriptElement;
        "section": HTMLElement;
        "select": HTMLSelectElement;
        "slot": HTMLSlotElement;
        "small": HTMLElement;
        "source": HTMLSourceElement;
        "span": HTMLSpanElement;
        "strike": HTMLElement;
        "strong": HTMLElement;
        "style": HTMLStyleElement;
        "sub": HTMLElement;
        "sup": HTMLElement;
        "table": HTMLTableElement;
        "tbody": HTMLTableSectionElement;
        "td": HTMLTableDataCellElement;
        "template": HTMLTemplateElement;
        "textarea": HTMLTextAreaElement;
        "tfoot": HTMLTableSectionElement;
        "th": HTMLTableHeaderCellElement;
        "thead": HTMLTableSectionElement;
        "time": HTMLTimeElement;
        "title": HTMLTitleElement;
        "tr": HTMLTableRowElement;
        "track": HTMLTrackElement;
        "tt": HTMLElement;
        "u": HTMLElement;
        "ul": HTMLUListElement;
        "var": HTMLElement;
        "video": HTMLVideoElement;
        "wbr": HTMLElement;
        "xmp": HTMLPreElement;
    }

    interface SVGElementTagNameMap {
        "circle": SVGCircleElement;
        "clippath": SVGClipPathElement;
        "defs": SVGDefsElement;
        "desc": SVGDescElement;
        "ellipse": SVGEllipseElement;
        "feblend": SVGFEBlendElement;
        "fecolormatrix": SVGFEColorMatrixElement;
        "fecomponenttransfer": SVGFEComponentTransferElement;
        "fecomposite": SVGFECompositeElement;
        "feconvolvematrix": SVGFEConvolveMatrixElement;
        "fediffuselighting": SVGFEDiffuseLightingElement;
        "fedisplacementmap": SVGFEDisplacementMapElement;
        "fedistantlight": SVGFEDistantLightElement;
        "feflood": SVGFEFloodElement;
        "fefunca": SVGFEFuncAElement;
        "fefuncb": SVGFEFuncBElement;
        "fefuncg": SVGFEFuncGElement;
        "fefuncr": SVGFEFuncRElement;
        "fegaussianblur": SVGFEGaussianBlurElement;
        "feimage": SVGFEImageElement;
        "femerge": SVGFEMergeElement;
        "femergenode": SVGFEMergeNodeElement;
        "femorphology": SVGFEMorphologyElement;
        "feoffset": SVGFEOffsetElement;
        "fepointlight": SVGFEPointLightElement;
        "fespecularlighting": SVGFESpecularLightingElement;
        "fespotlight": SVGFESpotLightElement;
        "fetile": SVGFETileElement;
        "feturbulence": SVGFETurbulenceElement;
        "filter": SVGFilterElement;
        "foreignobject": SVGForeignObjectElement;
        "g": SVGGElement;
        "image": SVGImageElement;
        "line": SVGLineElement;
        "lineargradient": SVGLinearGradientElement;
        "marker": SVGMarkerElement;
        "mask": SVGMaskElement;
        "metadata": SVGMetadataElement;
        "path": SVGPathElement;
        "pattern": SVGPatternElement;
        "polygon": SVGPolygonElement;
        "polyline": SVGPolylineElement;
        "radialgradient": SVGRadialGradientElement;
        "rect": SVGRectElement;
        "stop": SVGStopElement;
        "svg": SVGSVGElement;
        "switch": SVGSwitchElement;
        "symbol": SVGSymbolElement;
        "text": SVGTextElement;
        "textpath": SVGTextPathElement;
        "tspan": SVGTSpanElement;
        "use": SVGUseElement;
        "view": SVGViewElement;
    }

    interface ElementTagNameMap extends HTMLElementTagNameMap, SVGElementTagNameMap { }
}