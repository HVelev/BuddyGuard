import { DatePipe } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { RequestDTO } from '../../models/request.model';
import { ProcessRequestService } from '../../services/process-request.service';

@Component({
  selector: 'app-accept-requests',
  templateUrl: './accept-requests.component.html',
  styleUrls: ['./accept-requests.component.css']
})
export class AcceptRequestsComponent implements OnInit {
  private readonly service: ProcessRequestService;

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  public requests: RequestDTO[] = [];
  public displayedColumns: string[] = ['location', 'address', 'name', 'phone', 'meetingDate', 'startDate', 'endDate'];
  public datePipe: DatePipe;
  public dataSource: MatTableDataSource<RequestDTO>;
  public dialog: MatDialog;
  public dialogRef: any;

  public constructor(service: ProcessRequestService,
    datePipe: DatePipe,
    dialog: MatDialog) {
    this.service = service;
    this.datePipe = datePipe;
    this.dataSource = new MatTableDataSource<RequestDTO>();
    this.dialog = dialog;
  }

  public ngOnInit(): void {
    this.getAllRequests();
  }

  public ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  public getAllRequests(): void {
    this.service.getAllAcceptedRequests().subscribe({
      next: (value: RequestDTO[]) => {

        this.dataSource.data = value;
      }
    });
  }
}
