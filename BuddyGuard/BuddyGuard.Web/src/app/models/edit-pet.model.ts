export class EditPetDTO {
  public constructor(obj?: Partial<EditPetDTO>) {
    Object.assign(this, obj);
  }

  public name!: string;

  public species?: string;

  public petDescription?: string;

  public animalTypeId!: number;

  public services?: number[];
}
