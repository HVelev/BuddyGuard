import { DatePipe } from '@angular/common';
import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { EditRequestDTO } from '../../models/edit-request.model';
import { RequestDTO } from '../../models/request.model';
import { ProcessRequestService } from '../../services/process-request.service';
import { RequestService } from '../../services/request.service';
import { ProcessRequestDialogComponent } from './models/process-request-dialog/process-request-dialog.component';

@Component({
  selector: 'app-process-request',
  templateUrl: './process-request.component.html',
  styleUrls: ['./process-request.component.css'],
  providers: [DatePipe]
})
export class ProcessRequestComponent implements OnInit, AfterViewInit {
  private readonly service: RequestService;

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  public requests: RequestDTO[] = [];
  public displayedColumns: string[] = ['location', 'startDate', 'endDate', 'actions'];
  public datePipe: DatePipe;
  public dataSource: MatTableDataSource<RequestDTO>;
  public dialog: MatDialog;
  public dialogRef: any;

  constructor(service: RequestService,
    datePipe: DatePipe,
    dialog: MatDialog) {
    this.service = service;
    this.datePipe = datePipe;
    this.dataSource = new MatTableDataSource<RequestDTO>();
    this.dialog = dialog;
  }

  ngOnInit(): void {
    this.getAllRequests();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  public getAllRequests(): void {
    this.service.getAllRequests().subscribe({
      next: (value: RequestDTO[]) => {

        this.dataSource.data = value;
      }
    });
  }

  public async openRequest(id: number) {
    this.service.markRequestAsRead(id).subscribe();

    const response = await this.service.getRequest(id).toPromise();

    const dialogRef = this.dialog.open(ProcessRequestDialogComponent, {
      width: '100%',
      height: '100%',
      maxWidth: '100%',
      data: response
    });

    this.dialogRef = dialogRef;

    dialogRef.afterClosed().subscribe({
      next: () => {
        this.getAllRequests();
      }
    });
  }

  public deleteRequest(id: number) {
    this.service.deleteRequest(id).subscribe({
      next: () => {
        this.getAllRequests();
      }
    });
  }
}
