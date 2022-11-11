export class LoginDTO {
  public constructor(obj?: Partial<LoginDTO>) {
    Object.assign(this, obj);
  }

  public username!: string;

  public password!: string;
}
