var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
function GetRequest(urlString, data) {
    return __awaiter(this, void 0, void 0, function* () {
        const url = new URL(urlString, document.baseURI);
        if (data !== undefined) {
            Object.keys(data).forEach(key => url.searchParams.append(key, data[key]));
        }
        const response = yield fetch(url.toString());
        const result = yield response.json();
        return result;
    });
}
function PostRequest(url, data) {
    return __awaiter(this, void 0, void 0, function* () {
        const response = yield fetch(url, {
            method: "POST",
            headers: {
                'Content-Type': 'application/json; charset=utf-8',
            },
            body: JSON.stringify(data)
        });
        const result = yield response.json();
        return result;
    });
}
export { GetRequest, PostRequest };
//# sourceMappingURL=GetPostRequest.js.map