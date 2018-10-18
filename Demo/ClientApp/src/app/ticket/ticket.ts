export interface ITicket
{
  id: number;
  name: string;
  description?: string;
  priority?: Priority;
}

export enum Priority
{
  Low = 1,
  Normal = 10,
  High = 20,
}