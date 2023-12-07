export interface Agro {
    id: number;
    name: string;
    description: string;
    province: string;
    prize: number;
    picture: string;
}

export interface UptadatedAgro {
    Id: number;
    Name: string;
    Description: string;
}

export interface AgroAdded{
    id: number;
    name: string;
    description: string;
    province: string;
    prize: number;
    picture: string;
    productIds: number[]

}


