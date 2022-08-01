[TUTOR]
- Id
- Name
- Birthdate: DateTime
- CPF*
- CRMV**
- ZipCode*
- City*
- FederativeUnit*
- Address*
- PhoneNumber**
- Email*

[TYPE_OF_PROFESSIONAL]
- Id
- Type

[PROFESSIONAL]
- Id
- Name
- Type
- CRMV

[ESTABLISHMENT]
- Id
- Name
- CRMV
- ZipCode
- City
- FederativeUnit
- Address
- Number
- AddressComplement
- PhoneNumber

[ESTABLISHMENT_PROFESSIONALS]
- Id
- Establishment
- Professional

[ACTIVE_INGREDIENT]
- Id
- Name

[MEDICINE]
- Id
- Name
- ActiveIngredient

[SURGERY]
- Id
- Name

[VACCINE]
- Id
- Name

[PARASITE_CONTROL]
- Id 
- Prevention: DateTime
- PreventionDetails
- CheckUp: DateTime
- Bath: DateTime
- OnDay: Boolean

[REPRODUCTION_STAGE]
- Id
- Stage

[ANAMNESIS]
- Id
- Castrated
- ReproductionStage
- Height
- Weight
- Diet
- ParasiteControl

[ANAMNESIS_MEDICINE]
- Id
- Anamnesis
- Medicine
- Dose
- Interval
- Details

[ANAMNESIS_SURGERY]
- Id
- Anamnesis
- Surgery
- Details
- Date

[ANAMNESIS_VACCINE]
- Id
- Anamnesis
- Vaccine
- Date
- Expiration

[SPECIE]
- Id
- Specie

[BREED]
- Id
- Breed

[PET]
- Id
- Name
- Tutor
- Birthdate: DateTime
- Specie
- Breed
- Gender
- Anamnesis

[AGENDA]
- Id
- Tutor

[APPOINTMENT]
- Id
- Date: DateTime 
- Agenda
- Pet
- Establishment
- Professional

[APPOINTMENT_MEDICINE]
- Id
- Appointment
- Medicine
- Dose
- Interval
- Details

[APPOINTMENT_SURGERY]
- Id
- Appointment
- Surgery
- Details

[APPOINTMENT_VACCINE]
- Id
- Appointment
- Vaccine
- Expiration