// it might makes sense to separate these into one file per interface, but we'll see...

export interface Card {
  id: number;
  year: string;
  companyName: string;
  cardNumber: string;
  rc: string;
  personName: string;
  personId: number;
  teamName: string;
  teamId: number;
}
export interface College {
  id: number;
  name: string;
  cards: Card[]
}
export interface Person {
  id: number;
  name: string;
  cards: Card[]
}
export interface Sport {
  id: number;
  name: string;
  cards: Card[]
}
export interface Team {
  id: number;
  name: string;
  cards: Card[]
}


