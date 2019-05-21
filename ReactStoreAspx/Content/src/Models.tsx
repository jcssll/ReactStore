export interface FoodModel {
    Id: number;
    Description: string;
    Picture: number;
    Price: number;
    Quantity: number;
}

export interface IAppStat {
    items: FoodModel[];
    myOrder: FoodModel[];
    showPopup: boolean;
    userId: number;
    orderPlaced:boolean;
}