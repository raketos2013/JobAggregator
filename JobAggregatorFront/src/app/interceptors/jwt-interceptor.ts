import { HttpInterceptorFn } from "@angular/common/http";
import { AuthService } from "../services/auth-service";
import { inject } from "@angular/core";

export const jwtInterceptor: HttpInterceptorFn = (req, next) => {
  const authServcie = inject(AuthService);
  const token = authServcie.getAccessToken();
  if (token) {
    req = req.clone({
      setHeaders: {
        Authorization: `Bearer ${token}`,
      },
    });
  }
  return next(req);
};