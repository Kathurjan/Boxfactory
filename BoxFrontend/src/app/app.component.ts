import { Component, OnInit } from '@angular/core';
import { HttpService } from 'src/services/http.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  boxType: string = "";
  boxLength: number = 0;
  boxWidth: number = 0;
  boxToList: any;




  constructor(private http:HttpService) {


  }
  async ngOnInit(){
    const boxes = await this.http.getBoxes();

    this.boxToList = boxes;
    console.log(this.boxToList)
  }

   async createNewBox(){
     let box ={
       type: this.boxType,
       width: this.boxWidth,
       length: this.boxLength
     }
   const createdBox = await this.http.createBox(box);
    this.boxToList.push(createdBox)
  }

  async deleteBox(id:any) {
  const boxes = await this.http.deleteBoxById(id);
    // @ts-ignore
    this.boxToList = this.boxToList.filter(b => b.id != boxes.id)

  }
}
