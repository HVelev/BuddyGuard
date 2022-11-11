export class RegisterDTO {
  public constructor(obj?: Partial<RegisterDTO>) {
    Object.assign(this, obj);
  }

  public username!: string;

  public password!: string;
}
