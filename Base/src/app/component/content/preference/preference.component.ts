import { Component } from '@angular/core';

import { PreferenceService } from './../../../service/preference.service';
import { IPreference } from './../../../model/preference.models';

@Component({
    selector: 'preference',
    templateUrl: './preference.component.html'
})
export class PreferenceComponent {
    public City: IPreference[] = [];
    public Category: IPreference[] = [];

    public LoadingCity: boolean = true;
    public LoadingCategory: boolean = true;

    constructor(private _service: PreferenceService) { }

    ngOnInit() {
        this.Load();
    }

    private Load() {
        debugger;
        this.LoadCategory();
        this.LoadCity();
    }

    private LoadCategory() {
        this.LoadingCategory = true;
        this._service.GetCategoryPreference().subscribe(x => this.SetCategory(x));
    }

    private SetCategory(preference: IPreference[]) {
        this.LoadingCategory = false;
        this.Category = preference;
    }

    private LoadCity() {
        this.LoadingCity = true;
        this._service.GetCityPreference().subscribe(x => this.SetCity(x));
    }

    private SetCity(preference: IPreference[]) {
        this.LoadingCity = false;
        this.City = preference;
    }

    public Save(category: any[], city: any[]) {
        var tempCate = this.GetPreferences(category);
        var tempCity = this.GetPreferences(city);

        var resultCate = this.GetDiffrent(this.Category, tempCate);
        var resultCity = this.GetDiffrent(this.City, tempCity);
        debugger;
        if (resultCity.length > 0)
            this._service.UpdateCityPreference(resultCity).subscribe(() => this.LoadCity());
        if (resultCate.length > 0)
            this._service.UpdateCategoryPreference(resultCate).subscribe(() => this.LoadCategory());

    }

    private GetPreferences(list: any[]): IPreference[] {
        var result: IPreference[] = [];
        list.forEach(function (x) {
            result.push({ Id: x.value, Selected: x.selected, Name: "" });
        })
        return result;
    }

    private GetDiffrent(before: IPreference[], after: IPreference[]): IPreference[] {
        return after.filter(function (x) {
            var a = before.find(function (y) { return y.Id == x.Id; });
            return a.Selected != x.Selected;
        });
    }

}