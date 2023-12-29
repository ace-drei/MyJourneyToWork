import http from 'k6/http';
import { sleep, check } from 'k6';

export const options = {
  duration: '5m',
  vus: 50,
  thresholds: {
    http_req_duration: ['p(95)<500'],
  },
};

export default function () {
  let res = http.get('https://ca3devops.azurewebsites.net/', {tags: {name: 'Homepage'}});
  check(res, {
    'is status 200': (r) => r.status === 200,
    'text verification': (r) => r.body.includes('Welcome'),
  });
  sleep(Math.random() * 5);
}