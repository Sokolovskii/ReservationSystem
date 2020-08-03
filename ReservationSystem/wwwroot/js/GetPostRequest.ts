import { ServiceResponceGeneric, ServiceResponceNonGeneric, ServiseResponceCode } from './ServiceResponce'

async function GetRequest<T>(urlString: string, data?: any): Promise<ServiceResponceGeneric<T>> {
    const url = new URL(urlString, document.baseURI);
    if (data !== undefined) {
        Object.keys(data).forEach(key => url.searchParams.append(key,data[key]));
    }
    const response = await fetch(url.toString());
    const result = await response.json();
    return result as ServiceResponceGeneric<T>;
}

async function PostRequest<T>(url: string, data?: any): Promise<ServiceResponceGeneric<T>> {
    const response = await fetch(url, {
        method: "POST",
        headers: {
            'Content-Type': 'application/json; charset=utf-8',
        },
        body: JSON.stringify(data)
    });
    const result = await response.json();
    return result as ServiceResponceGeneric<T>;
}

export{ GetRequest, PostRequest }