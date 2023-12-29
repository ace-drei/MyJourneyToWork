import http from 'k6/http';
import { sleep, check } from 'k6';

export const options = {
    stages: [
      { duration: '30s', target: 50 }, // below normal load
      { duration: '1m', target: 200 }, // spike to 200 users
      { duration: '3m', target: 200 }, // stay at spike
      { duration: '1m', target: 0 }, // scale down to 0 users
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
