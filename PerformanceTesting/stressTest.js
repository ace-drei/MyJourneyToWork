import http from 'k6/http';
import { sleep, check } from 'k6';

export const options = {
    stages: [
        { duration: '2m', target: 20 }, // ramp up to 20 users
        { duration: '3m', target: 50 }, // stay at 50 users
        { duration: '1m', target: 100 }, // ramp up to 100 users
        { duration: '2m', target: 0 }, // scale down. Recovery stage
    ],
};

export default function () {
  let res = http.get('https://ca3devops.azurewebsites.net/', {tags: {name: 'Homepage'}});
  check(res, {
    'is status 200': (r) => r.status === 200,
    'text verification': (r) => r.body.includes('Welcome'),
  });
  sleep(Math.random() * 5);
}
