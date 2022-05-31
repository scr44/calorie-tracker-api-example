export class FoodType {
    public id: string = "";
    public name: string = "";
    public units: string = "";
    public caloriesPerUnit: string = "";

    constructor(foodType: FoodType | null = null) {
        if (foodType !== null) {
            this.id = foodType.id;
            this.name = foodType.name;
        }
    }
}