import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../../services/vehicle.service';

@Component({
    selector: 'app-vehicle-form',
    templateUrl: './vehicle-form.component.html'
})

/** vehicle-form component*/
export class VehicleFormComponent implements OnInit {
    public makes: any[] = new Array();
    public models: any[] = new Array();
    public features: any[] = new Array();
    public vehicle: any = new Object();

    /** vehicle-form ctor */
    constructor(
        private vehicleService: VehicleService) { }

    public ngOnInit() {
        this.vehicleService.getMakes().subscribe(makes => this.makes = makes);
        this.vehicleService.getFeatures().subscribe(features => this.features = features);
    }

    public onMakeChange() {
        var selectedMake = this.makes.find(m => m.id == this.vehicle.make);
        this.models = selectedMake ? selectedMake.models : [];
    }
}