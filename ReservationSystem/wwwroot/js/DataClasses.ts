
    export class PlaceInHall {
        id: number;
        row: number;
        column: number;
        userId: number;

        constructor(id: number, row: number, column: number, userId: number) {
            this.id = id;
            this.row = row;
            this.column = column;
            this.userId = userId;
        }
    }

    export class Session {
        id: number;
        timeOfBegin: string;
        timeOfEnd: string;
        cost: number;
        date: string;
        filmId: number;
        hallId: number;
    }

    export class PartialFilm {
        id: number;
        name: string;
        duration: number;
        genre: string;
    }

export class Person {
    id: number;
    name: string;
    login: string;
    passHash: string;
}
