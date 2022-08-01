import { TestBed } from '@angular/core/testing';

import { DialogueboxService } from './dialoguebox.service';

describe('DialogueboxService', () => {
  let service: DialogueboxService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DialogueboxService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
