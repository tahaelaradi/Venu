import MobileDetect from "mobile-detect";
export function useDeviceType() {
  const md = new MobileDetect(window.navigator.userAgent);
  let mobile = false,
    tablet = false,
    desktop = false;
  if (md.tablet()) {
    tablet = true;
  } else if (md.mobile()) {
    mobile = true;
  } else {
    desktop = true;
  }
  return {
    mobile,
    tablet,
    desktop
  };
}
