export class NomenclatureDTO<T> {
  public constructor(obj?: Partial<NomenclatureDTO<T>>) {
    Object.assign(this, obj);
  }

  public value!: T;

  public displayName!: string;

  public price?: number;
}
