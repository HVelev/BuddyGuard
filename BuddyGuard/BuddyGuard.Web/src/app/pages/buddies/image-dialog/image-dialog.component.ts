import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ImageDTO } from '../../../models/image.model';

@Component({
  selector: 'app-image-dialog',
  templateUrl: './image-dialog.component.html',
  styleUrls: ['./image-dialog.component.css']
})
export class ImageDialogComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: ImageDTO) { }

  ngOnInit(): void {
  }

}
