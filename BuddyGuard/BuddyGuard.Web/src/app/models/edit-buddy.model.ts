export class EditBuddyDTO {
  public constructor(obj?: Partial<EditBuddyDTO>) {
    Object.assign(this, obj);
  }

  public userId!: string;

  public comment!: string;
}
