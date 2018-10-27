﻿namespace GCModeller.Workbench {

    export class Logo {

        public alphabet;
        public fine_text;
        public pspm_list;
        public pspm_column;
        public rows: number = 0;
        public columns: number = 0;

        public constructor(alphabet, fine_text) {
            this.alphabet = alphabet;
            this.fine_text = fine_text;
            this.pspm_list = [];
            this.pspm_column = [];
        }

        public addPspm(pspm, column) {
            var col;

            if (typeof column === "undefined") {
                column = 0;
            } else if (column < 0) {
                throw new Error("Column index out of bounds.");
            }
            this.pspm_list[this.rows] = pspm;
            this.pspm_column[this.rows] = column;
            this.rows++;
            col = column + pspm.get_motif_length();
            if (col > this.columns) {
                this.columns = col;
            }
        }

        public getPspm(rowIndex: number) {
            if (rowIndex < 0 || rowIndex >= this.rows) {
                throw new Error("INDEX_OUT_OF_BOUNDS");
            }
            return this.pspm_list[rowIndex];
        }

        public getOffset(rowIndex) {
            if (rowIndex < 0 || rowIndex >= this.rows) {
                throw new Error("INDEX_OUT_OF_BOUNDS");
            }
            return this.pspm_column[rowIndex];
        };
    }
}