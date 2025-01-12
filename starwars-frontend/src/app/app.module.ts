import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BasicComponentComponent } from './basic-component/basic-component.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [AppComponent, BasicComponentComponent],
  imports: [BrowserModule, HttpClientModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
