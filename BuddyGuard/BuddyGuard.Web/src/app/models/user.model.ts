export class UserDTO {
  public constructor(obj?: Partial<UserDTO>) {
    Object.assign(this, obj);
  }
  public id!: string;

  public firstName!: string;

  public lastName!: string;

  public email!: string;

  public phone!: string;

  public address!: string;
}
