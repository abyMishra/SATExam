

import { ObjectId } from "mongodb"




export interface DestinationMasterData {
  [x: string]: any
  airport: Airport[]
  auditDetails: AuditDetails
  countryDetailsID: string
  cultureInfo: CultureInfo
  destinationCode: string
  destinationDescription: string
  destinationImage: DestinationImage[]
  destinationName: string
  district: string[]
  highLights: HighLights
  isActive: boolean
  location: Location
  Id?: ObjectId
  taxDetails: TaxDetail[]
  thingsToDo: ThingsToDo
  thingsToSee: ThingsToSee
}

export interface Airport {
  airportCode: string
  airportName: string
}

export interface AuditDetails {
  created_by: string
  created_date: string
  updated_by: string
  updated_date: string
}

export interface CultureInfo {
  country: string
  cultureName: string
  format: string
  timeZone: string
  writingSystem: string
}

export interface DestinationImage {
  altText: string
  description: string
  imageURL: string
  itineraryImage: string
}

export interface HighLights {
  description: string
  isActive: boolean
}

export interface Location {
  area: string
  latitude: string
  longitude: string
  population: number
  radius: string
}

export interface TaxDetail {
  country: string
  currencyDetails: string
  maxAge: number
  minAge: number
  taxRate: number
  taxType: string
  //Id?:ObjectId
}

export interface ThingsToDo {
  canonicalURL: string
  description: string
  imageURL: string
  pageURL: string
  subText: string
  urlSlug: string
}

export interface ThingsToSee {
  canonicalURL: string
  description: string
  imageURL: string
  pageURL: string
  subText: string
  urlSlug: string
}
