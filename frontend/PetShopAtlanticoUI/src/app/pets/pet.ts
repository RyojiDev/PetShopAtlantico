import { PetOwner } from '../pet-owner/petOwner';
import { PetAccomodation } from '../accomodation/petAccomodation'

export class Pet{
  constructor(){}

  name: string
  petHealth: number
  petPhotograph: string
  accomodationId: number
  petOwner: PetOwner
  petAccomodation: PetAccomodation
}