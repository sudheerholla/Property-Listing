import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public properties: Property[];
  private http: HttpClient;
  private baseUrl: string;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
    http.get<Properties>(baseUrl + 'api/properties').subscribe(result => {
      this.properties = result.properties;
    }, error => console.error(error));
  }

  public async addProperty(property : Property) {
    this.http.post<number>(this.baseUrl + 'api/properties', property).subscribe(result => {
      if(result === 1) {
        alert('Successfully saved');
      }
      else if(result === 0)
      {
        alert('Property already saved');
      }
      
    }, error => console.error(error));
  }
}

interface Property {
  id: number;
  address: string;
  yearBuilt: number;
  listPrice: number;
  monthlyRent: number;
  grossYield: number;
}

interface Properties {
  properties: Property[]
}

