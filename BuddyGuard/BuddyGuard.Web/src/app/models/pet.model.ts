export class PetDTO {
  public constructor(obj?: Partial<PetDTO>) {
    Object.assign(this, obj);
  }

  public name!: string;

  public species?: string;

  public petDescription?: string;

  public animalTypeId!: number;

  public services?: number[];
}
