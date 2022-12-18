export class RegisterDTO {
  public constructor(obj?: Partial<RegisterDTO>) {
    Object.assign(this, obj);
  }

  public firstName!: string;

  public lastName!: string;

  public email!: string;

  public phone!: string;

  public username!: string;

  public password!: string;

  public role!: string;
}
