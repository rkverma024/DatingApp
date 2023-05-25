import { Injectable } from '@angular/core';
import { CanActivateFn, CanDeactivate, CanDeactivateFn } from '@angular/router';
import { MemberEditComponent } from '../members/member-edit/member-edit.component';


@Injectable({
  providedIn: 'root'
})
export class PreventUnsavedChnagesGuard implements CanDeactivate<MemberEditComponent>{
  canDeactivate(component: MemberEditComponent): boolean{
    if(component.editForm?.dirty){
      return confirm('Are you sure you want to continue? Any unsaved changes will be lost');
    }
    return true;
  }
}



// export const preventUnsavedChnagesGuard: CanActivateFn = (route, state) => {
//   return true;
// };
