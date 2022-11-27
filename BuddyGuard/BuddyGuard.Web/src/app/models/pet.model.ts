export class PetDTO {
  public constructor(obj?: Partial<PetDTO>) {
    Object.assign(this, obj);
  }

  public name!: string;

  public species?: string;

  public petDescription?: string;

  public animalType!: string;

  public dogWalkLength!: string;

  public services?: string[];
}
