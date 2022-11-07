export class FormDTO {
  public constructor(obj?: Partial<FormDTO>) {
  Object.assign(this, obj);
  }

  public name!: string;

  public phone!: string;

  public email!: string;

  public location!: string;

  public species?: string;

  public dogWalk?: string;

  public startDate!: Date;

  public endDate!: Date;
}
