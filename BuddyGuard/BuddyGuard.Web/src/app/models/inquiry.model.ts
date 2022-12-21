export class InquiryDTO {
  public constructor(obj?: Partial<InquiryDTO>) {
    Object.assign(this, obj);
  }

  public firstName!: string;

  public lastName!: string;

  public email!: string;

  public phone!: string;

  public inquiry!: string;
}
