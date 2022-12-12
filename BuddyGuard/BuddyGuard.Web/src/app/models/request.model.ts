import { PetDTO } from "./pet.model";

export class RequestDTO {
  public constructor(obj?: Partial<RequestDTO>) {
    Object.assign(this, obj);
  }
  public id!: number;

  public firstName!: string;

  public lastName!: string;

  public email!: string;

  public phone!: string;

  public startDate!: Date;

  public endDate!: Date;

  public sentDate!: Date;

  public location!: string;

  public address!: string;

  public meetingDate?: Date;

  public clientServices?: string[];

  public comment?: string;

  public price!: number;

  public pets!: PetDTO[];
}
