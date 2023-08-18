import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Watchlist } from 'src/app/models/watchlist.model';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { WatchlistService } from 'src/app/services/watchlist.service';

@Component({
  selector: 'app-watchlist',
  templateUrl: './watchlist.component.html',
  styleUrls: ['./watchlist.component.css'],
})
export class WatchlistComponent implements OnInit {
  watchlist: Watchlist[] = [];
  constructor(
    private authService:AuthenticationService,
    private wathclistService: WatchlistService,
    private activeRoute: ActivatedRoute,
    private router: Router
  ) {}
  ngOnInit(): void {
    this.getAll(this.authService.customerId);
  }

  getAll(customerId: string) {
    this.wathclistService
      .getAll(parseInt(customerId))
      .then((watchlist) =>  watchlist && (this.watchlist = watchlist))
      .catch((err) => console.log(err));
  }

  deleteOne(dvdCatalogId:number){
    this.wathclistService.deleteOne(parseInt(this.authService.customerId),dvdCatalogId)
    .then(s => {
      this.getAll(this.authService.customerId);
    })
    .catch(err => console.log(err));
  }
}
