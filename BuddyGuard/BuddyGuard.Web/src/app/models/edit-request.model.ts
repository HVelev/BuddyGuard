import { EditPetDTO } from "./edit-pet.model";

export class EditRequestDTO {
  public constructor(obj?: Partial<EditRequestDTO>) {
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

  public comment?: string;
    
  public pets!: EditPetDTO[];

  public services?: number[];
}
