import { Component, OnInit } from "@angular/core";
import { SpinerService } from "./services/spiner.service";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"]
})
export class AppComponent implements OnInit{
  
  title = "app";
  isLoadingInProgress: boolean;

  constructor(private _spiner: SpinerService){
    
  }

  public ngAfterViewInit(): void {
    // We use setTimeout to avoid the `ExpressionChangedAfterItHasBeenCheckedError`
    // See: https://github.com/angular/angular/issues/6005
    setTimeout(_ => this.isLoadingInProgress = false);
  }

  ngOnInit() {
    // standing data
    this._spiner.status.subscribe((val: boolean) => {
      this.isLoadingInProgress = val;
    });

    this.isLoadingInProgress = true;
  }

}
