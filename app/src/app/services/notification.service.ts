import { Injectable } from '@angular/core';
declare var swal: any

@Injectable()
export class NotificationService {

  constructor() { }

  sucess(title:string, msg:string, btnConfirmationText:string = "Ok"){
    swal({
      title: title,
      text: msg,
      type: 'success',
      confirmButtonText: btnConfirmationText
    })
  }

  info(title:string, msg:string, btnConfirmationText:string = "Ok"){
    swal({
      title: title,
      text: msg,
      type: 'info',
      confirmButtonText: btnConfirmationText
    })
  }

  error(title:string, msg:string, btnConfirmationText:string = "Ok"){
    swal({
      title: title,
      text: msg,
      type: 'error',
      confirmButtonText: btnConfirmationText
    })
  }

  warning(title:string, msg:string, btnConfirmationText:string = "Ok"){
    swal({
      title: title,
      text: msg,
      type: 'warning',
      confirmButtonText: btnConfirmationText
    })
  }
}
