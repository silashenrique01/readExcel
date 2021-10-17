import { FileService } from './../services/file.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Readexcel';
  form:FormGroup = new FormGroup({});

  constructor(private service: FileService) {

  }

  ngOnInit(){
    this.form = new FormGroup({
      anexos: new FormControl()
    });
  }

  onSubmit() {
    let file = new FormData();
    file.append("file", this.form.controls.anexos.value.files[0])
    this.service.sendFile(file).subscribe(res => {
      // mostra no log o ultimo registro passado pelo excel
      console.log(res)
    });
  }
}
