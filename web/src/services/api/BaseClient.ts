import axios, { AxiosInstance, AxiosResponse } from "axios"

export class BaseClient {

    static client: AxiosInstance = axios.create({ 
        baseURL: "https://mpuoezidw9.execute-api.us-east-1.amazonaws.com/Prod", 
        headers: { Accept: 'application/json', 'Content-Type': 'application/json' } 
    });

    public static get = async <T> (url: string): Promise<T> => {
        const response: AxiosResponse<T> = await BaseClient.client.get<T>(url);
        return response.data;
    }

    public static put = async <T> (url: string, data: any): Promise<T> => {
        const response: AxiosResponse<T> = await BaseClient.client.put<T>(url, data);
        return response.data;
    }
}