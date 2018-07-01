import { TestBed, inject } from '@angular/core/testing';
import { ProductGuardService } from './product-guard.service';
describe('ProductGuardService', function () {
    beforeEach(function () {
        TestBed.configureTestingModule({
            providers: [ProductGuardService]
        });
    });
    it('should be created', inject([ProductGuardService], function (service) {
        expect(service).toBeTruthy();
    }));
});
//# sourceMappingURL=product-guard.service.spec.js.map