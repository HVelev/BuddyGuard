export class ImageDTO {
  public constructor(obj?: Partial<ImageDTO>) {
    Object.assign(this, obj);
  }

  public name?: string;

  public description?: string;

  public image?: Blob;
}
