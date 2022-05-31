import { FoodType } from "@/classes/FoodType";
import axios, { Axios, AxiosInstance } from "axios";

class FoodTypeApiClient {
    private axiosClient: AxiosInstance;

    constructor() {
        this.axiosClient = axios.create({
            baseURL: "https://localhost:7005",
            timeout: 10000,
            headers: { "X-Custom-Header": "foobar" }
        })
    }

    public async GetFoodType(id: string): Promise<Array<FoodType>> {
        const foodTypes = await this.axiosClient.get<Array<FoodType>>(`food-type/get/${id}`)

        return foodTypes.data;
    }

    public async GetAllFoodType(): Promise<Array<FoodType>> {
        const foodTypes = await this.axiosClient.get<Array<FoodType>>(`food-type/get`)

        return foodTypes.data;
    }
}

export const FoodTypeApiClientInstance = new FoodTypeApiClient();