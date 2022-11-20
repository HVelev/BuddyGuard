import { PetDTO } from "./pet.model";

export class RequestDTO {
  public constructor(obj?: Partial<RequestDTO>) {
  Object.assign(this, obj);
  }

  public userId!: string;

  public locationId!: number;

  public totalAmount!: number;

  public startDate!: string;

  public endDate!: string;

  public isRead!: boolean;

  public isAccepted!: boolean;

  public requestSentDate?: Date;
    
  public pets!: PetDTO[];

  public services?: number[];
}
