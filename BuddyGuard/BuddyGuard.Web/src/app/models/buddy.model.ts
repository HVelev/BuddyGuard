export class EditBuddyDTO {
  public constructor(obj?: Partial<EditBuddyDTO>) {
    Object.assign(this, obj);
  }
  public image!: Blob;

  public comment!: string;

  public username!: string;
}
