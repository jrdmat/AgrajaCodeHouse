export interface Box {
    id: number;
    name: string;
    description: string;
    kg: number;
    prize: number;
    stock: number;
    picture: string;
}

export interface UpdatedBox {
    Id: number;
    Name: string;
    Description: string;
    Stock: number
}

export interface BoxAdded {
    id: number;
    name: string;
    description: string;
    kg: number;
    prize: number;
    stock: number;
    picture: string;
    productIds: number[]

}
