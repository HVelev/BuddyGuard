export enum InvalidPasswordEnum {
  PasswordTooShort = 'Паролата трябва да съдържа поне 6 символа',
  PasswordRequiresNonAlphanumeric = 'Паролата трябва да има поне един специален символ',
  PasswordRequiresUpper = 'Паролата трябва да има главна буква',
  PasswordRequiresLower = 'Паролата трябва да има малка буква',
  PasswordRequiresDigit = 'Паролата трябва да има число'
}
