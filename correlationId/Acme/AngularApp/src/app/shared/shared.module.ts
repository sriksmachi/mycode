import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { CustomFooterComponent } from './components/customfooter/customfooter.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { StarComponent } from './components/star.component';

@NgModule({
    imports: [
        CommonModule,
        RouterModule
    ],

    declarations: [
        NavigationComponent,
        CustomFooterComponent,
        StarComponent
    ],

    exports: [
        NavigationComponent,
        CustomFooterComponent,
        StarComponent
    ]
})

export class SharedModule { }
