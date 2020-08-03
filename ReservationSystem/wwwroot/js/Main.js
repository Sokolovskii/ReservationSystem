import * as jsrender from 'jsrender';
window.onload = function () {
    var data = [
        {
            "id": 1,
            "row": 1,
            "column": 1,
            "userId": 0
        },
        {
            "id": 2,
            "row": 2,
            "column": 1,
            "userId": 1
        },
        {
            "id": 3,
            "row": 3,
            "column": 1,
            "userId": 2
        }
    ];
    const tmpl = jsrender.templates('{{for}}{{:id}}{{/for}}');
    const html = tmpl.render(data);
};
//# sourceMappingURL=Main.js.map