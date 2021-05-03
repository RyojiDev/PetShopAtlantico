import { PetOwner } from '../pet-owner/petOwner';

export class Pet{
  constructor(){}

  name: string
  petHealth: number
  petPhotograph: string
  accomodationId: number
  petOwner: PetOwner
}