export class NotificationDTO {
  public constructor(obj?: Partial<NotificationDTO>) {
    Object.assign(this, obj);
  }
  public id!: number;

  public firstName?: string;

  public lastName?: string;

  public sentDate?: string;

  public startDate?: string;
}
