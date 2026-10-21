//
// This is only a SKELETON file for the 'Line Up' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

function getOrdinal(num) {
  let secondToLastDigit = Math.floor(num / 10) % 10;
  let lastDigit = num % 10;

  if (secondToLastDigit !== 1 && lastDigit === 1) {
    return `${num}st`;
  } else if (secondToLastDigit !==  1 && lastDigit === 2) {
    return `${num}nd`;
  } else if (secondToLastDigit !== 1 && lastDigit === 3) {
    return `${num}rd`;
  } else {
    return `${num}th`
  }
}

export function format(name, num) {
  return `${name}, you are the ${getOrdinal(num)} customer we serve today. Thank you!`;
};
